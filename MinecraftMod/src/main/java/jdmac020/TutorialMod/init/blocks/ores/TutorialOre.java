package jdmac020.TutorialMod.init.blocks.ores;

import java.util.Random;

import jdmac020.TutorialMod.init.TutorialBlocks;
import jdmac020.TutorialMod.init.TutorialItems;
import jdmac020.TutorialMod.init.TutorialTabs;
import net.minecraft.block.Block;
import net.minecraft.block.material.Material;
import net.minecraft.block.state.IBlockState;
import net.minecraft.init.Blocks;
import net.minecraft.item.Item;
import net.minecraft.item.ItemStack;
import net.minecraft.util.math.BlockPos;
import net.minecraft.util.math.MathHelper;
import net.minecraft.world.IBlockAccess;
import net.minecraft.world.World;

public class TutorialOre extends Block
{
	public TutorialOre()
	{
		super(Material.ROCK);
		setCreativeTab(TutorialTabs.tabTutorialBlocks);
	}
	
	//determine the item dropped based on what block "this" is
	public Item getItemDropped(IBlockState state, Random rand, int fortune)
	{
		return this == TutorialBlocks.RUBY_ORE ? TutorialItems.RUBY : Item.getItemFromBlock(this);
	}
	
	//determine the amount dropped based on fortune (or no fortune)
	public int quantityDroppedWithBonus(int fortune, Random rand)
	{
		if(fortune > 0 && Item.getItemFromBlock(this) != this.getItemDropped((IBlockState)this.getBlockState().getValidStates().iterator().next(), rand, fortune))
		{
			int i = rand.nextInt(fortune + 2) - 1;
			if (i < 0)
			{
				i = 0;
			}
			return this.quantityDropped(rand) * (i + 1);
		} 
		else
		{
			return this.quantityDropped(rand);
		}
	}
	
	//bring the drops into the world as entities
	public void dropBlockAsItemWithChance(World worldIn, BlockPos pos, IBlockState state, float chance, int fortune)
	{
		super.dropBlockAsItemWithChance(worldIn, pos, state, chance, fortune);
	}
	
	//generate the experience dropped
	@Override
	public int getExpDrop(IBlockState state, IBlockAccess World, BlockPos pos, int fortune)
	{
		Random rand = World instanceof World ? ((World)World).rand : new Random();
        if (this.getItemDropped(state, rand, fortune) != Item.getItemFromBlock(this))
        {
            int i = 0;

            if (this == TutorialBlocks.RUBY_ORE)
            {
                i = MathHelper.getRandomIntegerInRange(rand, 2, 8);
            }
            //else if (this == Blocks.DIAMOND_ORE)
            //{
            //    i = MathHelper.getRandomIntegerInRange(rand, 3, 7);
            //}

            return i;
        }
        return 0;
	}
	
	public ItemStack getItem(World world, BlockPos pos, IBlockState state)
	{
		return new ItemStack(this);
	}
}

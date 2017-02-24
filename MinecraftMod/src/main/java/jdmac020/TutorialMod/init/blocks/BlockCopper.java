package jdmac020.TutorialMod.init.blocks;

import jdmac020.TutorialMod.init.TutorialTabs;
import net.minecraft.block.Block;
import net.minecraft.block.material.Material;

public class BlockCopper extends Block
{

	public BlockCopper() 
	{
		super(Material.IRON);
		setRegistryName("copper_block");
		setUnlocalizedName("copper_block");
		setHardness(5F);
		setCreativeTab(TutorialTabs.tabTutorialBlocks);
	}

}

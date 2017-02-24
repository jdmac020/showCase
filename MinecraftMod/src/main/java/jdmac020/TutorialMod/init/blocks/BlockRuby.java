package jdmac020.TutorialMod.init.blocks;

import jdmac020.TutorialMod.init.TutorialTabs;
import net.minecraft.block.Block;
import net.minecraft.block.material.Material;

public class BlockRuby extends Block {

	public BlockRuby() 
	{
		super(Material.GLASS);
		setRegistryName("ruby_block");
		setUnlocalizedName("ruby_block");
		setHardness(5F);
		setCreativeTab(TutorialTabs.tabTutorialBlocks);
	}

}

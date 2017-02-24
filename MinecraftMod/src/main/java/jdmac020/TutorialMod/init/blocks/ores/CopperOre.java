package jdmac020.TutorialMod.init.blocks.ores;

import jdmac020.TutorialMod.init.TutorialTabs;
import net.minecraft.block.Block;
import net.minecraft.block.material.Material;

public class CopperOre extends Block 
{

	public CopperOre() 
	{
		super(Material.ROCK);
		setRegistryName("copper_ore");
		setUnlocalizedName("copper_ore");
		setHarvestLevel("pickaxe",2);
		setHardness(2F);
		setResistance(8F);
		setCreativeTab(TutorialTabs.tabTutorialBlocks);
	}

}
